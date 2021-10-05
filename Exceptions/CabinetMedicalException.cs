// <copyright file="CabinetMedicalException.cs" company="Angelo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.Exceptions
{
    using System;
    using System.Text.Json;

    /// <summary>
    /// Exception pour les cabinets médicales.
    /// </summary>
    public class CabinetMedicalException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CabinetMedicalException"/> class.
        /// </summary>
        /// <param name="message">Message de l'erreur.</param>
        public CabinetMedicalException(string message)
            : base("Erreur : " + message)
        {
        }

        /// <summary>
        /// Récupère l'objet au format json indenté.
        /// </summary>
        /// <param name="journalisation">Journalisation.</param>
        /// <returns>Chaine json.</returns>
        public string GetExceptionJson(Journalisation journalisation)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string jsonString = JsonSerializer.Serialize(journalisation, options);

            return jsonString;
        }
    }
}
