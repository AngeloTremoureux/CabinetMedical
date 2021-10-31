// <copyright file="Prestation.cs" company="PlaceholderCompany">
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
    /// Une prestation.
    /// </summary>
    public class Prestation
    {
        private string libelle;
        private DateTime dateHeureSoin;
        private Intervenant intervenant;
        private Dictionary<Cotation, int> cotations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">Libellé.</param>
        /// <param name="dateHeureSoin">Date du soin.</param>
        /// <param name="intervenant">Intervenant.</param>
        /// <param name="cotations">Cotations.</param>
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant, Dictionary<Cotation, int> cotations)
        {
            if (dateHeureSoin > DateTime.Now)
            {
                throw new CabinetMedicalException("La date de prestation ne peut être supérieur à la date du jour");
            }
            else
            {
                this.dateHeureSoin = dateHeureSoin;
            }

            this.libelle = libelle;
            this.intervenant = intervenant;
            this.cotations = cotations;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">Libellé.</param>
        /// <param name="dateHeureSoin">Date du soin.</param>
        /// <param name="intervenant">Intervenant.</param>
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant)
            : this(libelle, dateHeureSoin, intervenant, new Dictionary<Cotation, int>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">Libellé.</param>
        /// <param name="dateHeureSoin">Date du soin.</param>
        /// <param name="intervenant">Intervenant.</param>
        /// <param name="cotation">Cotation.</param>
        /// <param name="nombre">Nombre.</param>
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant, Cotation cotation, int nombre)
            : this(libelle, dateHeureSoin, intervenant)
        {
            this.cotations.Add(cotation, nombre);
        }

        /// <summary>
        /// Gets or sets the libelle.
        /// </summary>
        public string Libelle { get => this.libelle; set => this.libelle = value; }

        /// <summary>
        /// Gets or sets la date de soin.
        /// </summary>
        public DateTime DateHeureSoin { get => this.dateHeureSoin; set => this.dateHeureSoin = value; }

        /// <summary>
        /// Gets or sets l'intervenant.
        /// </summary>
        public Intervenant Intervenant { get => this.intervenant; set => this.intervenant = value; }

        /// <summary>
        /// Gets la nomenclature de la prestation.
        /// </summary>
        public Dictionary<Cotation, int> Cotations { get => this.cotations; }

        /// <summary>
        /// Méthode qui compare la date de 2 prestations.
        /// </summary>
        /// <param name="p1">Prestation 1.</param>
        /// <param name="p2">Prestation 2.</param>
        /// <returns>Intervalle entre les deux prestations.</returns>
        public static int CompareTo(Prestation p1, Prestation p2)
        {
            return DateTime.Compare(p1.DateHeureSoin.Date, p2.DateHeureSoin.Date);
        }

        /// <summary>
        /// Récupère le prix total de la prestation.
        /// </summary>
        /// <returns>Prix.</returns>
        public double GetPrixPrestation()
        {
            double prixCumul = 0;
            foreach (KeyValuePair<Cotation, int> cotation in this.cotations)
            {
                prixCumul += cotation.Key.Indice * cotation.Value;
            }

            return prixCumul;
        }

        /// <summary>
        /// Ajoute une charge à la prestation.
        /// </summary>
        /// <param name="cotation">Element d'une nomenclature.</param>
        /// <param name="nombre">Nombre d'element.</param>
        public void AjoutePrix(Cotation cotation, int nombre)
        {
            this.cotations.Add(cotation, nombre);
        }
    }
}
