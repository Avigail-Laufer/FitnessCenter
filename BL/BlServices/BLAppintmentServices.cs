using BL.BLApi;
using BL.BO;
using Dal.DalApi;
using Server.Models;
using fitness_center;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models;
using Dal;

namespace BL.BlServices;

public class BLAppintmentServices : IAppointmentBL
{
    #region prop
    IAppointment appointment;
    ISighnToDal sighn;
    IClientDal client;
    IMapper mapper;
    #endregion

    #region func
    public BLAppintmentServices(DalManager dal)
    {
        appointment = dal.Appointmemt;
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();
        sighn = dal.sighnTo;
        client = dal.Clients;
    }
    public List<BLAppointment> GetAllAppointmentByIdBL(string id)
    {
        List<SignTo> time = appointment.GetAllAppointmentByIdBL();
        List<BLAppointment> appointments = new List<BLAppointment>();
        foreach (var item in time)
        {
            if (item.IdClient.Equals(id))
            {
                BLAppointment s = new(item);
                appointments.Add(s);
            }

        }
        return appointments;
    }
    BLgetAppointment IAppointmentBL.AddAppointmentBL(BLgetAppointment appointmen)
    {
        SignTo s = appointment.AddApointment((mapper.Map<SignTo>(appointmen)));
        return appointmen;
            
    }
    BLgetAppointment IAppointmentBL.RemoveAppointmentBL(BLgetAppointment appointmen)
    {
        List<SignTo> appointments = appointment.GetAllAppointmentByIdBL();
        SignTo appointmentToRemove = appointments.FirstOrDefault(item => item.IdClient == appointmen.idClient && item.CodeDate == appointmen.codeDate);

        if (appointmentToRemove != null)
        {
            appointment.RemoveApointment(new SignTo()
            {
                Id = appointmentToRemove.Id,
                CodeDate = appointmen.codeDate,
                IdClient = appointmen.idClient
            }

                );
            return appointmen;
        }

        return null;

    }
    public BLpossibleAppointment NumberOfPossibleAppointment(string id)
    {
        var c = client.GetClientWhithTypeMember(id);
        if (c == null)
        {
            return null;
        }
        int count = c.SignTos.Count();
        return new BLpossibleAppointment(Convert.ToInt32( c.TypeMemberCodeNavigation.CountTraining) - count);

    }
    public bool IfCanAddApointment(int codeDate,string id)
    {
        List<SignTo> appointments = appointment.GetAllAppointmentByIdBL();
        SignTo? appoint = appointments.FirstOrDefault(item =>item.IdClient  == id && item.CodeDate==codeDate);
        if(appoint == null) { return true; }
        return false;
    }
    #endregion
}
