using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultWill
{

    public class DocumentAssignmentFolder
    {
        public string FolderName { get; set; }
        public string ParentFolderName { get; set; }
        public string DisplayName { get; set; }
        public bool RemoveSourceFilesWhenAssigningToFolder { get; set; }
        public string FileAssignmentRenamePattern { get; set; }
        public bool UseLargeImages { get; set; }
    }



}
