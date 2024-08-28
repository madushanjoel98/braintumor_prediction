using AuthApp.model.bra;
using AuthApp.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using PandasNet;
using Microsoft.AspNetCore.Cors;
namespace AuthApp.controller
{

    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {


        [HttpGet("getUser")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> getuser()
        {



            var data = new { name = "d" };
            return ResponseModel.CreateResponse(data, "Success", HttpStatusCode.OK);
        }

        [HttpPost("setUsers")]
        public async Task<IActionResult> setuser()
        {


            try
            {
                var data = new { name = "d" };
                return ResponseModel.CreateResponse(data, "Success", HttpStatusCode.OK);
            }
            catch (Exception w)
            {

                return ResponseModel.CreateResponse(null, w.Message, HttpStatusCode.BadRequest);

            }

        }
        [HttpPost("tumor")]
        public async Task<IActionResult> tumor([FromBody] Braintu_Model model)
        {


            try
            {
                if (string.IsNullOrEmpty(model.Type))
                {
                   
                }
                //Load sample data
                var sampleData = new Braintumore.ModelInput()
                {
                    Location = @model.Location,
                    Size__cm_ = model.Size__cm_,
                    Patient_Age = model.Patient_Age,
                    Gender = model.Gender,
                    Tumor_Type=model.Type
                };

                //Load model and predict output
                var result = Braintumore.Predict(sampleData);
                var outbut = new
                {
                    result = result.PredictedLabel,
                    scores = result.Features
                };
                return ResponseModel.CreateResponse(outbut, "Success", HttpStatusCode.OK);
            }
            catch (Exception w)
            {

                return ResponseModel.CreateResponse(null, w.Message, HttpStatusCode.BadRequest);

            }

        }

        [HttpPost("getlocation")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> getlocation()
        {


            try
            {
                String[] d = {"Ependymoma","Meningioma","Glioblastoma","Astrocytoma","Oligodendroglioma"
                };
                string[] tutype = { "Ependymoma", "Meningioma", "Glioblastoma", "Astrocytoma", "Oligodendroglioma" };
                string[] tumorLocations = new string[]
                {
    "Occipital Lobe",
    "Cerebellum",
    "Brainstem",
    "Temporal Lobe",
    "Frontal Lobe",
    "Parietal Lobe"
};

                String[] genders = { "Male", "Female" };
                var data = new
                {
                    genders = genders,
                    alltypes = d,
                    tumorLocations = tumorLocations,
                    grade = new string[] { "I", "II", "III", "IV" },
                    tumorstype=tutype

                };
                //Load sample data

                return ResponseModel.CreateResponse(data, "Success", HttpStatusCode.OK);
            }
            catch (Exception w)
            {

                return ResponseModel.CreateResponse(null, w.Message, HttpStatusCode.BadRequest);

            }

        }
    }
}
