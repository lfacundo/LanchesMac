namespace LanchesMac.Models.Pagination
{
    public class Pagination
    {
        public string draw { get; set; }
        public string start { get; set; }
        public string length { get; set; }
        public string sort { get; set; }
        public string sortDir { get; set; }
        public string search { get; set; }
        public int pageSize { get; set; }
        public int skip { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }

        public Pagination(HttpRequest request)
        {

            draw = request.Form["draw"].FirstOrDefault();

            // Skip number of Rows count  
            start = request.Form["start"].FirstOrDefault();

            // Paging Length 10, 20  
            length = request.Form["length"].FirstOrDefault();

            // Sort Column Name  
            sort = request.Form["columns[" + request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            // Sort Column Direction (asc, desc)  
            sortDir = request.Form["order[0][dir]"].FirstOrDefault();

            // Search Value from (Search box)  
            search = request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10, 20, 50,100)  
            pageSize = length != null ? Convert.ToInt32(length) : 0;

            skip = start != null ? Convert.ToInt32(start) : 0;

            recordsTotal = 0;

            recordsFiltered = 0;
        }
    }
}
