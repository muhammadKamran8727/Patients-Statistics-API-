using Microsoft.AspNetCore.Mvc;
using Patient_Statistic_And_Device_Inventory.Models;

namespace Patient_Statistic_And_Device_Inventory.IBussinessLogic
{
    public interface PatientStatIBL
    {
        Response CreateStatistics(Patient_Statistics patient_Statistics);
        Response GetPatientStats();
        Response GetPatientStatById(long serial_no);
        Response UpdatePatientStatistics(Patient_Statistics patient_Statistics, long serial_No);
    }
}
