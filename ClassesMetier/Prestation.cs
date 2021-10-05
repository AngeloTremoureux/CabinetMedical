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

        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">Libellé.</param>
        /// <param name="dateHeureSoin">Date du soin.</param>
        /// <param name="intervenant">Intervenant.</param>
        public Prestation(string libelle, DateTime dateHeureSoin, Intervenant intervenant)
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
            intervenant.Prestations.Add(this);
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
        /// Méthode qui compare la date de 2 prestations.
        /// </summary>
        /// <param name="p1">Prestation 1.</param>
        /// <param name="p2">Prestation 2.</param>
        /// <returns>Intervalle entre les deux prestations.</returns>
        public static int CompareTo(Prestation p1, Prestation p2)
        {
            return DateTime.Compare(p1.DateHeureSoin.Date, p2.DateHeureSoin.Date);
        }
    }
}
