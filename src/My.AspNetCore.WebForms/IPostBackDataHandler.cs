using System.Collections.Generic;

namespace My.AspNetCore.WebForms
{
    public interface IPostBackDataHandler
    {
        void LoadPostData(IDictionary<string, string> postBackData);
    }
}
