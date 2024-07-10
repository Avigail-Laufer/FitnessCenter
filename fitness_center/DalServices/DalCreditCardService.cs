using Dal.DalApi;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalServices
{
    public class DalCreditCardService : ICreditCard
    {
        BlogsSiteContext _fitnessCenter;

        #region basic func
        public DalCreditCardService(BlogsSiteContext fitnessCenter) {
            _fitnessCenter = fitnessCenter;
        }
        public CreditCard Post(CreditCard card)
        {
           
                _fitnessCenter.CreditCards.Add(card);
                _fitnessCenter.SaveChanges();
                return card;
            
        }
        #endregion
    }
}
