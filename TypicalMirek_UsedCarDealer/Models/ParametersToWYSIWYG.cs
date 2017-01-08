using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToWysiwyg
    {
        /// <summary>
        /// Name of site wchich text is edited
        /// </summary>
        [Required]
        public string SiteName { get; set; }
        /// <summary>
        /// Text to display in wysiwyg
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// Name of Action method to take POST request - by default "Save"
        /// </summary>
        public string ActionNameForPost { get; set; }
        /// <summary>
        /// Name of Controller to take POST request - by default "Api"
        /// </summary>
        public string ControllerNameForPost { get; set; }
        /// <summary>
        /// Height of wysiwyg window - by default number of text lines
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// Minimum height of wysiwyg window - by default null
        /// </summary>
        public int? MinHeight { get; set; }
        /// <summary>
        /// Maximum height of wysiwyg window - by default null
        /// </summary>
        public int? MaxHeight { get; set; }
        /// <summary>
        /// Focus to editable area after initializing - by default true
        /// </summary>
        public bool? Focus { get; set; }
    }
}