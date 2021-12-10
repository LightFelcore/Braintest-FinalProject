using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinformsproject.Model
{
    public class TakeQuizAnswer
    {
        public String PreviewAnswer { get; set; }

        public override string ToString()
        {
            return PreviewAnswer;
        }
    }
}
