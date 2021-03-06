using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Db.Api.Mvc
{
    public class CoreRtControllerBase : ControllerBase
    {
        // NOTE: This is probably a terrible idea, but right now async endpoints are hitting
        // an assertion in CoreRT (GetRuntimeInterfaceMap() is not supported on this runtime.)
        // So we defer the actual async handling to later.
        // 
        // See: https://github.com/dotnet/corert/issues/7453
        protected DeferredExecutionResult Defer(Func<HttpContext, Task> exec)
        {
            return new DeferredExecutionResult(exec);
        }

        protected void AllowSynchronousIO()
        {
            var syncIoFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
            if (syncIoFeature != null) syncIoFeature.AllowSynchronousIO = true;
        }
    }
}