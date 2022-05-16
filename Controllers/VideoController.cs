// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace video.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private IWebHostEnvironment env;

        public VideoController(IWebHostEnvironment _env)
        {
            env = _env;
        }

        [HttpGet]
        public FileResult get(string fname, string type)
        {
            // ----- 情況 1 (type == 1)，影片在前端 wwwroot 目錄下 -----
            // ----- 情況 2 (type == 2)，影片不在前端 wwwroot 目錄下 ----

            // 專案根目錄
            string ContentRootPath = this.env.ContentRootPath;
            
            // 影片路徑
            string path = (type == "y") 
                            ? $"videos/{fname}"  // wwwroot 下的相對路徑
                            : $"{ContentRootPath}/videos/{fname}";   // 檔案系統的絕對路徑

            // 回傳檔案 (ios 系統 contentType 需要指定明確的類型，ex：video/mp4)
            return (type == "y")
                    ? File(path, contentType: "video/mp4", enableRangeProcessing: true)
                    : PhysicalFile(path, contentType: "application/octet-stream", enableRangeProcessing: true);
        }
    }
}
