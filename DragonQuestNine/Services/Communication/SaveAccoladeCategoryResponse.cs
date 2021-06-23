using DragonQuestNine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Services.Communication
{
    public class SaveAccoladeCategoryResponse : BaseResponse
    {
        public AccoladeCategory AccoladeCategory { get; private set; }

        private SaveAccoladeCategoryResponse(bool success, string message, AccoladeCategory accoladeCategory) : base(success, message)
        {
            AccoladeCategory = accoladeCategory;
        }
        /// <summary>
        /// Create a save response.
        /// </summary>
        /// <param name="accoladeCategory">Saved Accolade Category</param>
        /// <returns>Response.</returns>
        
        public SaveAccoladeCategoryResponse(AccoladeCategory accoladeCategory) : this(true,string.Empty, accoladeCategory) { }

        /// <summary>
        /// Creates and error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        
        public SaveAccoladeCategoryResponse(string message) : this(false, message, null)
        { }
    }
}
