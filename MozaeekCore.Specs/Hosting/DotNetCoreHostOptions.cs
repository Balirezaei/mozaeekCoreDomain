﻿namespace MozaeekCore.Specs.Hosting
{
    public class DotNetCoreHostOptions
    {
        /// <summary>
        /// Path that target ASP.NET Core project exists. It can be either relative path or absolute path.
        /// </summary>
        public string CsProjectPath { get; set; }

        /// <summary>
        /// Port that target ASP.NET Core project is configured to run.
        /// </summary>
        public int Port { get; set; }

    }
}
