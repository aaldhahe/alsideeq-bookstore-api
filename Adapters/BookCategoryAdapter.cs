using alsideeq_bookstore_api.DTOs;
using MySqlConnector;
using System.Collections.Generic;

namespace alsideeq_bookstore_api.Adapters
{
    public class BookCategoryAdapter : BaseAdapter
    {
        public CategoryDTO ToCategoryDTO(MySqlDataReader data)
        {   
            CategoryDTO category = new CategoryDTO();
            AssignModelValueToDomain<string>(s => category.CategoryId = (string)s, data["category_id"]);
            AssignModelValueToDomain<string>(s => category.Title = (string)s, data["title"]);
            AssignModelValueToDomain<string>(s => category.Description = (string)s, data["description"]);
            return category;
        }

        public List<CategoryDTO> ToCategoryDTOList(MySqlDataReader data)
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            while(data.Read())
            {
                categories.Add(ToCategoryDTO(data));
            }
            return categories;
        }
    }
}