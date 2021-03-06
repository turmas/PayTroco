﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayTroco.Core.DataContracts {

    public abstract class AbstractRequest {

        public AbstractRequest() {
            this.ValidationReport = new List<Report>();
        }

        /// <summary>
        /// Obtém a flag que indica se os dados recebidos são válidos.
        /// </summary>
        internal bool IsValid {
            get {
                this.ValidationReport.Clear();
                this.Validate();
                return (this.ValidationReport.Any() == false);
            }
        }

        internal List<Report> ValidationReport { get; set; }

        protected void AddError(string field, string message) {

            string fullPropertyName = this.GetType().Name + "." + field;

            Report report = new Report(fullPropertyName, message);
            this.ValidationReport.Add(report);
        }

        protected abstract void Validate();
    }
}
