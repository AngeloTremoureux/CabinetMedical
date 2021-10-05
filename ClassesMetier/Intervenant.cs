// <copyright file="Intervenant.cs" company="Angelo">
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
    /// Classe correspondant à un intervenant.
    /// </summary>
    public class Intervenant
    {
        private string nom;
        private string prenom;
        private List<Prestation> prestations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prénom.</param>
        public Intervenant(string nom, string prenom)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.prestations = new List<Prestation>();
        }

        /// <summary>
        /// Gets or sets the firstname.
        /// </summary>
        public string Nom { get => this.nom; set => this.nom = value; }

        /// <summary>
        /// Gets or sets the lastname.
        /// </summary>
        public string Prenom { get => this.prenom; set => this.prenom = value; }

        /// <summary>
        /// Gets the list of prestations.
        /// </summary>
        public List<Prestation> Prestations { get => this.prestations; }

        /// <summary>
        /// Ajoute une prestation.
        /// </summary>
        /// <param name="prestation">Prestation.</param>
        public void AjoutePrestation(Prestation prestation)
        {
            this.prestations.Add(prestation);
        }

        /// <summary>
        /// Retourne le nombre de prestations d'un intervenant.
        /// </summary>
        /// <returns>Nombre de prestations.</returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count;
        }

        /// <summary>
        /// Affiche l'objet sous format texte.
        /// </summary>
        /// <returns>Objet au format string.</returns>
        public override string ToString()
        {
            return this.Nom + " - " + this.Prenom;
        }
    }
}
