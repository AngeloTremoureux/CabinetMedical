// <copyright file="Cotation.cs" company="Angelo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabinetMedical.ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Cotation d'une prestation.
    /// </summary>
    public class Cotation
    {
        private int id;
        private string libelle;
        private double indice;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cotation"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="libelle">Libellé.</param>
        /// <param name="indice">Valeur.</param>
        public Cotation(int id, string libelle, double indice)
        {
            this.id = id;
            this.libelle = libelle;
            this.indice = indice;
        }

        /// <summary>
        /// Gets id.
        /// </summary>
        public int Id { get => this.id; }

        /// <summary>
        /// Gets libelle.
        /// </summary>
        public string Libelle { get => this.libelle; }

        /// <summary>
        /// Gets or sets prize.
        /// </summary>
        public double Indice { get => this.indice; set => this.indice = value; }
    }
}
