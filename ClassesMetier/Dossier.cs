// <copyright file="Dossier.cs" company="Angelo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CabinetMedical.Exceptions;

    /// <summary>
    /// Dossier d'une personne.
    /// </summary>
    public class Dossier
    {
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private DateTime dateCreation;
        private List<Prestation> prestations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prénom.</param>
        /// <param name="dateNaissance">Date de naissance.</param>
        /// <param name="dateCreation">Date de création.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, DateTime dateCreation)
        {
            if (dateCreation <= DateTime.Now)
            {
                this.dateCreation = dateCreation;
            }
            else
            {
                throw new CabinetMedicalException("La date de création du dossier ne peut être supérieur à la date actuelle");
            }

            this.nom = nom;
            this.prenom = prenom;
            if (dateNaissance <= DateTime.Now)
            {
                this.dateNaissance = dateNaissance;
            }
            else
            {
                throw new CabinetMedicalException("La date de naissance ne peut être supérieur à la date actuelle");
            }

            this.prestations = new List<Prestation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prénom.</param>
        /// <param name="dateNaissance">Date de naissance.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance)
            : this(nom, prenom, dateNaissance, DateTime.Now)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prénom.</param>
        /// <param name="dateNaissance">Date de naissance.</param>
        /// <param name="prestations">Liste de prestations.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, List<Prestation> prestations)
            : this(nom, prenom, dateNaissance)
        {
            this.prestations = prestations;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nom">Nom.</param>
        /// <param name="prenom">Prénom.</param>
        /// <param name="dateNaissance">Date de naissance.</param>
        /// <param name="prestation">Prestations.</param>
        public Dossier(string nom, string prenom, DateTime dateNaissance, Prestation prestation)
            : this(nom, prenom, dateNaissance)
        {
            this.prestations.Add(prestation);
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
        /// Gets or sets la date de naissance.
        /// </summary>
        public DateTime DateNaissance { get => this.dateNaissance; set => this.dateNaissance = value; }

        /// <summary>
        /// Gets la liste de prestation du dossier.
        /// </summary>
        public List<Prestation> Prestations => this.prestations;

        /// <summary>
        /// Gets la date de création du dossier.
        /// </summary>
        public DateTime DateCreation { get => this.dateCreation; }

        /// <summary>
        /// Ajoute une prestation au dossier.
        /// </summary>
        /// <param name="prestation">Prestation.</param>
        public void AjoutePrestation(Prestation prestation)
        {
            if (prestation.DateHeureSoin > this.dateCreation)
            {
                this.prestations.Add(prestation);
            }
            else
            {
                throw new CabinetMedicalException("La date de prestation entrée est invalide");
            }
        }

        /// <summary>
        /// Ajoute une prestation au dossier.
        /// </summary>
        /// <param name="libelle">Libellé.</param>
        /// <param name="dateHeureSoin">Date du soin.</param>
        /// <param name="intervenant">Intervenant de la prestation.</param>
        public void AjoutePrestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant)
        {
            this.AjoutePrestation(new Prestation(libelle, dateHeureSoin, intervenant));
        }

        /// <summary>
        /// Retourne le nombre de prestations externes.
        /// </summary>
        /// <returns>Nb de prestations externes.</returns>
        public int GetNbPrestationsExternes()
        {
            int nbPrestationsExternes = 0;

            foreach (Prestation prestation in this.prestations)
            {
                if (prestation.Intervenant is IntervenantExterne)
                {
                    nbPrestationsExternes++;
                }
            }

            return nbPrestationsExternes;
        }

        /// <summary>
        /// Retourne le nombre de prestations.
        /// </summary>
        /// <returns>Nb prestations.</returns>
        public int GetNbPrestations()
        {
            return this.prestations.Count;
        }

        /// <summary>
        /// Retourne le nombre de jours soins du dossier.
        /// </summary>
        /// <returns>Nb de jours soins.</returns>
        public int GetNbJoursSoins()
        {
            int nbPrestation = this.prestations.Count();
            for (int i = 0; i < this.prestations.Count(); i++)
            {
                for (int j = i + 1; j < this.prestations.Count(); j++)
                {
                    if (Prestation.CompareTo(this.prestations[j], this.prestations[i]) <= 0)
                    {
                        nbPrestation--;
                        i++;
                    }
                }
            }

            return nbPrestation;
        }

        /// <summary>
        /// Retourne le nombre de jours soins du dossier.
        /// </summary>
        /// <returns>Nb de jours soins.</returns>
        public int GetNbJoursSoinsV2()
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Prestation prestation in this.prestations)
            {
                if (!dates.Contains(prestation.DateHeureSoin.Date))
                {
                    dates.Add(prestation.DateHeureSoin.Date);
                }
            }

            return dates.Count;
        }

        /// <summary>
        /// Retourne le nombre de jours soins du dossier.
        /// </summary>
        /// <returns>Nb de jours soins.</returns>
        public int GetNbJoursSoinsV3()
        {
            int nb = this.prestations.Count;
            List<DateTime> dates = new List<DateTime>();
            foreach (Prestation prestation in this.prestations)
            {
                dates.Add(prestation.DateHeureSoin.Date);
            }

            dates.Sort();

            for (int i = 0; i < this.prestations.Count; i++)
            {
                if (i < (this.prestations.Count - 1) && this.prestations[i].DateHeureSoin.Date == this.prestations[i + 1].DateHeureSoin.Date)
                {
                    nb--;
                }
            }

            return nb;
        }

        /// <summary>
        /// Affiche le contenu de l'objet.
        /// </summary>
        /// <returns>Objet au format string.</returns>
        public override string ToString()
        {
            string message = string.Empty;
            message += "---------- Début dossier ----------";
            message += "\n* Nom: " + this.Nom + " Prenom: " + this.Prenom + "\n* Date de naissance: " + this.DateNaissance.ToString("dd/MM/yyyy") + "\n";
            foreach (Prestation prestation in this.prestations)
            {
                message += "\n\tLibelle " + prestation.Libelle + " - " + prestation.DateHeureSoin + " - Intervenant " + prestation.Intervenant;
            }

            message += "\n---------- Fin dossier ----------";
            return message;
        }
    }
}
