using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_Statistic_And_Device_Inventory.BussinessLogic;
using Patient_Statistic_And_Device_Inventory.IBussinessLogic;
using Patient_Statistic_And_Device_Inventory.Models;

namespace Patient_Statistic_And_Device_Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientStatController : ControllerBase
    {
        
        private readonly PatientStatIBL _patientstatBL;
       
        public PatientStatController( PatientStatIBL patientstatBL)
        {
            
            _patientstatBL = patientstatBL;
          
        }

        // ------------------------CREATE STATISTICS Method-----------------------------//
        [HttpPost("CreatePatientStatistics")]
        public ApiResponse CreateStatistics([FromBody] Patient_Statistics patient_Statistics)
        {
            try
            {
                var response = _patientstatBL.CreateStatistics(patient_Statistics);
                if (response != null && response.IsError == false)
                    return new ApiResponse { StatusCode = 200, Message = response.Message };

                return new ApiResponse { StatusCode = 500, Message = response.Message, Result = response.Result };
            }
            catch (Exception ex)
            {
                return new ApiResponse { StatusCode = 401, Message = ex.Message };
            }
        }


        // -------------------------GET USER Method---------------------------------//
        [HttpGet("GetPatientStats")]
        public ApiResponse GetPatientStats()
        {
            try
            {
                var response = _patientstatBL.GetPatientStats();
                if (response != null)
                    return new ApiResponse { StatusCode = 200, Message = "Success", Result = response.Result };

                return new ApiResponse { StatusCode = 404, Message = "Error Not Found!", Result = response.Result };


            }

            catch (Exception ex)
            {
                return new ApiResponse { StatusCode = 401, Message = ex.Message };
            }

        }


        // -------------------------Get a specific User By ID---------------------------------//
        [HttpGet("GetPatientStatByID")]
        public ApiResponse GetPatientStatById(long serial_no)
        {
            try
            {
                var response = _patientstatBL.GetPatientStatById(serial_no);
                if (response != null)
                    return new ApiResponse { StatusCode = 200, Message = response.Message, Result = response.Result };

                return new ApiResponse { StatusCode = 404, Message = "Error Not Found!", };


            }

            catch (Exception ex)
            {
                return new ApiResponse { StatusCode = 401, Message = ex.Message };
            }

        }


        // -------------------------Updation of User Method---------------------------------//
        [HttpPut("UpdatePatientStatistics")]
        public ApiResponse UpdatePatientStatistics([FromBody] Patient_Statistics patient_Statistics, long serial_No)
        {
            try
            {
                var response = _patientstatBL.UpdatePatientStatistics(patient_Statistics, serial_No);
                if (response == null)
                {
                    return new ApiResponse { StatusCode = 401, Message = response.Message, Result = response.Result };
                }
                return new ApiResponse { StatusCode = 200, Message = response.Message, Result = response.Result };
            }
            catch (Exception ex)
            {
                return new ApiResponse { StatusCode = 401, Message = ex.Message };
            }
        }



    }
}
