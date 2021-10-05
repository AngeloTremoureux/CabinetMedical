// <copyright file="Journalisation.cs" company="Angelo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Classe journalisation qui contient les éléments de logs.
    /// </summary>
    public class Journalisation
    {
        /// <summary>
        /// Gets or sets application name.
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// Gets or sets class exception.
        /// </summary>
        public string ClasseException { get; set; }

        /// <summary>
        /// Gets or sets date.
        /// </summary>
        public DateTime DateException { get; set; }

        /// <summary>
        /// Gets or sets message of exception.
        /// </summary>
        public string MessageException { get; set; }

        /// <summary>
        /// Gets or sets user exception.
        /// </summary>
        public string UserException { get; set; }

        /// <summary>
        /// Gets or sets the user machine name exception.
        /// </summary>
        public string UserMachine { get; set; }
    }
}
