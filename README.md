# task 2

```sql
SELECT Product.Name,
       Category.Name
FROM Product
LEFT JOIN ProductCategory ON Product.Id = ProductCategory.ProductId
JOIN Category ON ProductCategory.CategoryId = Category.Id;
```
