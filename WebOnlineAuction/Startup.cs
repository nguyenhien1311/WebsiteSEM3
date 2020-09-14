﻿using CKSource.CKFinder.Connector.Config;
using CKSource.CKFinder.Connector.Core.Builders;
using CKSource.CKFinder.Connector.Core.Logs;
using CKSource.CKFinder.Connector.Host.Owin;
using CKSource.FileSystem.Local;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebOnlineAuction.Startup))]

namespace WebOnlineAuction
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            /*
             * If you installed CKSource.CKFinder.Connector.Logs.NLog you can start the logger:
             * LoggerManager.LoggerAdapterFactory = new NLogLoggerAdapterFactory();
             * Keep in mind that the logger should be initialized only once and before any other
             * CKFinder method is invoked.
             */

            /*
             * Register the "local" type backend file system.
             */
            FileSystemFactory.RegisterFileSystem<LocalStorage>();

            /*
             * Map the CKFinder connector service under a given path. By default the CKFinder JavaScript
             * client expects the ASP.NET connector to be accessible under the "/ckfinder/connector" route.
             */
            app.Map("/ckfinder/connector", SetupConnector);

        }

        private static void SetupConnector(IAppBuilder app)
        {
            /*
             * Create a connector instance using ConnectorBuilder. The call to the LoadConfig() method
             * will configure the connector using CKFinder configuration options defined in Web.config.
             */
            var connectorFactory = new OwinConnectorFactory();
            var connectorBuilder = new ConnectorBuilder();

            /*
             * Create an instance of authenticator implemented in the previous step.
             */
            var customAuthenticator = new CustomCKFinderAuthenticator();


            connectorBuilder
                /*
                 * Provide the global configuration.
                 *
                 * If you installed CKSource.CKFinder.Connector.Config, you should load the static configuration
                 * from XML:
                 * connectorBuilder.LoadConfig();
                 */
                .LoadConfig()
                .SetAuthenticator(customAuthenticator)
                .SetRequestConfiguration(
                    (request, config) =>
                    {
                        /*
                         * If you installed CKSource.CKFinder.Connector.Config, you might want to load the static
                         * configuration from XML as a base configuration to modify:
                         */
                        config.LoadConfig();
                    }
                );

            /*
             * Build the connector middleware.
             */
            var connector = connectorBuilder
                .Build(connectorFactory);

            /*
             * Add the CKFinder connector middleware to the web application pipeline.
             */
            app.UseConnector(connector);
        }
    }
}
