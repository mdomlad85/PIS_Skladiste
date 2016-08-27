﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models.BirmiStorage
{
    public class Izdatnica
    {
        private const string _requiredMsg = "Polje je obavezno!";

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(128)]
        [DisplayName("Zaprimio")]
        [Required(ErrorMessage = _requiredMsg)]
        public string DjelatnikID { get; set; }

        [ForeignKey("DjelatnikID")]
        public Djelatnik Djelatnik { get; set; }

        [DisplayName("Datum izdavanja")]
        [Required(ErrorMessage = _requiredMsg)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DatumIzdavanja { get; set; }
        public int StatusID { get; set; }

        [DisplayName("Status")]
        [ForeignKey("StatusID")]
        public virtual StatusDokumenta Status { get; set; }

        public ICollection<StavkaIzdatnice> StavkeIzdatnice { get; set; }
        public ICollection<Proizvod> Proizvodi { get; set; }
    }
}