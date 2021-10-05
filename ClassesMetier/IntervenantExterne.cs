// <copyright file="IntervenantExterne.cs" company="Angelo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Intervenant externe.
    /// </summary>
    public class IntervenantExterne : Intervenant
    {
        private string specialite;
        private string adresse;
        private string tel;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervenantExterne"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prénom.</param>
        /// <param name="specialite">Spécialité.</param>
        /// <param name="adresse">Adresse.</param>
        /// <param name="tel">Numéro de téléphone.</param>
        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, string tel)
            : base(nom, prenom)
        {
            this.Specialite = specialite;
            this.Adresse = adresse;
            this.Tel = tel;
        }

        /// <summary>
        /// Gets or sets speciality.
        /// </summary>
        public string Specialite { get => this.specialite; set => this.specialite = value; }

        /// <summary>
        /// Gets or sets adress.
        /// </summary>
        public string Adresse { get => this.adresse; set => this.adresse = value; }

        /// <summary>
        /// Gets or sets telephone number.
        /// </summary>
        public string Tel { get => this.tel; set => this.tel = value; }

        /// <summary>
        /// Méthode qui affiche l'objet au format texte.
        /// </summary>
        /// <returns>Objet au format string.</returns>
        public override string ToString()
        {
            return base.ToString() + " Spécialité : " + this.Specialite + " - " + this.Adresse + " - " + this.Tel;
        }
    }
}
