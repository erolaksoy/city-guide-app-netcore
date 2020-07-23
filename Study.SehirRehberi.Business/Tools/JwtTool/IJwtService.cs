using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Study.SehirRehberi.Business.Tools.JwtTool
{
    public interface IJwtService
    {
      JwtToken GenerateJwt(User user);
    }
}
