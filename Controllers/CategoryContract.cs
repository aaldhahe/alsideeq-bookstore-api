using System;
using alsideeq_bookstore_api.DTOs;
using alsideeq_bookstore_api.Exceptions;
using alsideeq_bookstore_api.Adapters;

namespace alsideeq_bookstore_api.Controllers
{
    internal class CategoryContract : BaseContract 
    {
        private BookCategoryAdapter _adapter;
        internal CategoryContract(BookCategoryAdapter adapter)
        {
            _adapter = adapter;
        }

        internal CategoryContract()
        {
            _adapter = new BookCategoryAdapter();
        }
        internal CategoryDTO CreateCategory(CategoryDTO category)
        {
            Guid guid = ContentGuid;
            string query = BuildInsertCategoryQuery(guid, category);
            using (var dataSource = DataSource)
            {
                dataSource.Open();
                QueryDataSource(query, dataSource);
                dataSource.Close();
            }
            category.CategoryId = guid.ToString();
            return category;
        }

        private string BuildInsertCategoryQuery(Guid guid, CategoryDTO category)
        {
            return string.Format(@"INSERT INTO Book_Category (category_id, title, description)
                                    VALUES ('{0}', '{1}', '{2}')", guid, category.Title, category.Description);
        }

        internal bool CheckIfCategoryExist(string title)
        {
            CategoryDTO category = null;
            try
            {
                category = GetCategoryByTitle(title);
            }
            catch(NotFoundException ex)
            {
                return false;
            }
            return true;
        }

        internal CategoryDTO GetCategoryByTitle(string title)
        {
            string query = string.Format(
                @"SELECT * 
                FROM Book_Category
                WHERE title = '{0}'", title);
            CategoryDTO dto;
            using (var dataSource = DataSource)
            {
                dataSource.Open();
                var queryResult = QueryDataSource(query, dataSource);
                if (!queryResult.Read())
                {
                    throw new NotFoundException("Cannot find book category with title " + title);
                }
                dto = _adapter.ToCategoryDTO(queryResult);
                dataSource.Close();
            }
            return dto;
        }
    }
}