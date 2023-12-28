using Microsoft.AspNetCore.Mvc;
using Patient_Statistic_And_Device_Inventory.IBussinessLogic;
using Patient_Statistic_And_Device_Inventory.Models;

namespace Patient_Statistic_And_Device_Inventory.BussinessLogic
{
    public class PatientStatBL : PatientStatIBL
    {

        private readonly PateintContext _dbContext;
        public PatientStatBL(PateintContext dbContext)
        {
            _dbContext = dbContext;

        }
        
        // Create a Stattistics 
        public Response CreateStatistics(Patient_Statistics patient_Statistics)
        {
            try
            {
                var newCreate = new Patient_Statistics
                {
                    Total_Practices = patient_Statistics.Total_Practices,
                    Active_Practices = patient_Statistics.Active_Practices,
                    InActive_Practices = patient_Statistics.InActive_Practices,

                    Total_Vendors = patient_Statistics.Total_Vendors,
                    CCM_Patient = patient_Statistics.CCM_Patient,
                    RTM_Patient = patient_Statistics.RTM_Patient,
                    RPM_Patient = patient_Statistics.RPM_Patient,
                    Available_Device = patient_Statistics.Available_Device,
                    Allowcated_Device = patient_Statistics.Allowcated_Device,
                    Mal_Functioned_Devices = patient_Statistics.Mal_Functioned_Devices,
                    Reterive_Device = patient_Statistics.Reterive_Device,
                    Practice_Admin = patient_Statistics.Practice_Admin,
                    Medical_Assistant = patient_Statistics.Medical_Assistant,
                    Staff = patient_Statistics.Staff,
                    Blood_Pressure_Dev = patient_Statistics.Blood_Pressure_Dev,
                Weight_Device = patient_Statistics.Weight_Device,
                Glocumenter_Device = patient_Statistics.Glocumenter_Device,
                Pulse_Oximeter = patient_Statistics.Pulse_Oximeter,

            };
                _dbContext.patient_statistics.Add(newCreate);
                _dbContext.SaveChanges();
                return new Response { IsError = false, Message = "Patient Statistics Add successfully!", Result = newCreate };

            }
            catch (Exception ex)
            {
                return new Response { IsError = true, Message = ex.Message };
            }
        }

        // Get ALL Patient Statistics

        public Response GetPatientStats()
        {
            try
            {
                var patientstat = _dbContext.patient_statistics.Select(p => new Patient_Statistics
                {
                    Serial_No = p.Serial_No,
                    Total_Practices = p.Total_Practices,
                    Active_Practices = p.Active_Practices,
                    InActive_Practices = p.InActive_Practices,
                    Total_Vendors = p.Total_Vendors,
                    CCM_Patient = p.CCM_Patient,
                    RTM_Patient = p.RTM_Patient,
                    RPM_Patient = p.RPM_Patient,
                    Available_Device = p.Available_Device,
                    Allowcated_Device = p.Allowcated_Device,
                    Mal_Functioned_Devices = p.Mal_Functioned_Devices,
                    Reterive_Device = p.Reterive_Device,
                    Practice_Admin = p.Practice_Admin,
                    Medical_Assistant = p.Medical_Assistant,
                    Staff = p.Staff,
                   Blood_Pressure_Dev = p.Blood_Pressure_Dev,
                   Weight_Device = p.Weight_Device,
                    Glocumenter_Device = p.Glocumenter_Device,
                   Pulse_Oximeter = p.Pulse_Oximeter,

            }).ToList();
                return new Response { IsError = false, Message = "Here is ALL Patient Statistics", Result = patientstat };
            }
            catch (Exception ex)
            {
                return new Response { IsError = true, Message = ex.Message };
            }

        }


        // -------------------------Get a specific Patient Stat By ID---------------------------------//

        public Response GetPatientStatById(long serial_no)
        {
            try
            {
                var Getuser = _dbContext.patient_statistics.Where(p => p.Serial_No ==serial_no).FirstOrDefault();

                if (Getuser != null)
                {
                    return new Response { IsError = false, Message = "Your Required Patient Stat Successfully Get!", Result = Getuser };
                }
                return new Response { IsError = false, Message = "No Patient Stat Available With This ID" };


            }
            catch (Exception ex)
            {
                return new Response { IsError = true, Message = ex.Message };
            }

        }


        // Update Patient Statistics
       
        public Response UpdatePatientStatistics(Patient_Statistics patient_Statistics, long serial_No)
        {
            try
            {
                var da = _dbContext.patient_statistics.Where(p => p.Serial_No == serial_No).FirstOrDefault();
                if (da != null)
                {

                    da.Total_Practices = patient_Statistics.Total_Practices;
                    da.Active_Practices = patient_Statistics.Active_Practices;
                    da.InActive_Practices = patient_Statistics.InActive_Practices;
                    da.Total_Vendors = patient_Statistics.Total_Vendors;
                    da.CCM_Patient = patient_Statistics.CCM_Patient;
                    da.RTM_Patient = patient_Statistics.RTM_Patient;
                    da.RPM_Patient = patient_Statistics.RPM_Patient;
                    da.Available_Device = patient_Statistics.Available_Device;
                    da.Allowcated_Device = patient_Statistics.Allowcated_Device;
                    da.Mal_Functioned_Devices = patient_Statistics.Mal_Functioned_Devices;
                    da.Reterive_Device = patient_Statistics.Reterive_Device;
                    da.Practice_Admin = patient_Statistics.Practice_Admin;
                    da.Medical_Assistant = patient_Statistics.Medical_Assistant;
                    da.Staff = patient_Statistics.Staff;
                    da.Blood_Pressure_Dev = patient_Statistics.Blood_Pressure_Dev;
                    da.Weight_Device = patient_Statistics.Weight_Device;
                    da.Glocumenter_Device = patient_Statistics.Glocumenter_Device;
                    da.Pulse_Oximeter = patient_Statistics.Pulse_Oximeter;

                    _dbContext.patient_statistics.Update(da);
                    _dbContext.SaveChanges();
                    return new Response { IsError = false, Message = "PatientStatistics Updated successfully!", Result = da };
                }
                return new Response { IsError = false, Message = "PatientStatistics", Result = null };
            }
            catch (Exception ex)
            {
                return new Response { IsError = true, Message = ex.Message };
            }
        }


    }
}
