﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Umbraco.GridData.Config {
    
    /// <summary>
    /// Class representing the configuration of a text editor.
    /// </summary>
    public class GridEditorTextConfig : GridJsonObject, IGridEditorConfig {

        #region Properties

        /// <summary>
        /// Gets the parent editor of the configuration.
        /// </summary>
        public GridEditor Editor { get; private set; }

        /// <summary>
        /// Gets the style properties for the text.
        /// </summary>
        [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
        public string Style { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Style"/> property has a value.
        /// </summary>
        public bool HasStyle {
            get { return !String.IsNullOrWhiteSpace(Style); }
        }

        /// <summary>
        /// Gets the markup for the text.
        /// </summary>
        [JsonProperty("markup", NullValueHandling = NullValueHandling.Ignore)]
        public string Markup { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="Markup"/> property has a value.
        /// </summary>
        public bool HasMarkup {
            get { return !String.IsNullOrWhiteSpace(Markup); }
        }

        #endregion

        #region Constructors

        private GridEditorTextConfig(GridEditor editor, JObject obj) : base(obj) {
            Editor = editor;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="GridEditorTextConfig"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="editor">The parent editor.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static GridEditorTextConfig Parse(GridEditor editor, JObject obj) {
            if (obj == null) return null;
            return new GridEditorTextConfig(editor, obj) {
                Style = obj.GetString("style"),
                Markup = obj.GetString("markup")
            };
        }

        #endregion

    }

}
