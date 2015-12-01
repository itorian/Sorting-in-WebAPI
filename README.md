# Sorting-in-WebAPI
This project is all about sorting in WebAPI. Assume your client is interested in sorting data in ascending or descending order, your WebAPI should handle these requests by accepting sort string by query string. Look into below GET method. You will find ApplySort method call which will take comma separated shor string and send it to ApplySort extension method with source data. This will do sorting very easily.

        public IHttpActionResult Get(string sort = "id")
        {
            // Convert data source into IQueryable
            // ApplySort method needs IQueryable data source hence we need to convert it
            // Or we can create ApplySort to work on list itself
            var data = db.AsQueryable();

            // Apply sorting
            data = data.ApplySort(sort);

            // Return response
            return Ok(data);
        }
        
        
        
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string strSort)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            if(strSort == null)
            {
                return source;
            }

            var lstSort = strSort.Split(',');

            string sortExpression = string.Empty;

            foreach(var sortOption in lstSort)
            {
                if(sortOption.StartsWith("-"))
                {
                    sortExpression = sortExpression + sortOption.Remove(0, 1) + " descending,";
                }
                else
                {
                    sortExpression = sortExpression + sortOption + ",";
                }
            }

            if(!string.IsNullOrWhiteSpace(sortExpression))
            {
                // Note: system.linq.dynamic NuGet package is required here to operate OrderBy on string
                source = source.OrderBy(sortExpression.Remove(sortExpression.Count() - 1));
            }

            return source;
        }
