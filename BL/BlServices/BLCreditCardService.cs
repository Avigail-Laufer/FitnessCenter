using AutoMapper;
using BL.BLApi;
using BL.Models;
using Dal;
using Dal.DalApi;
using fitness_center;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BL.BlServices;

public class BLCreditCardService : ICreditCardBL
{
    #region prop
    ICreditCard card;
    IMapper mapper;
    #endregion

    #region func
    public BLCreditCardService(DalManager dal)
    {

        card = dal.card;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();



    }
    public BLCreditCard Post(BLCreditCard cards)
    {
        CreditCard c = card.Post(mapper.Map<CreditCard>(cards));
        cards.Id = c.Id;
        return cards;
    }
    #endregion
}
