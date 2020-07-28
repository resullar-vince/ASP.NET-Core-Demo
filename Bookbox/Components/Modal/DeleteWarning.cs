using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bookbox.Components
{
    public class DeleteWarning : ViewComponent
    {
        public class DeleteModalProperties
        {
            public string ModalTitle { get; set; }
            public string ModalMessage { get; set; }
            public string ModalDeleteLabel { get; set; }
            public string ModalCancelLabel { get; set; }
        }
        public IViewComponentResult Invoke(string title, string message, string deleteLabel, string cancelLabel)
        {
            DeleteModalProperties props = new DeleteModalProperties()
            {
                ModalTitle = title,
                ModalMessage = message,
                ModalDeleteLabel = deleteLabel,
                ModalCancelLabel = cancelLabel
            };

            return View("DeleteWarning", props);
        }
    }
}
