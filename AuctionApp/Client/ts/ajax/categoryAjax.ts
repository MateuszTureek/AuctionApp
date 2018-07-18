export default class CategoryAjax {
    getSubcategoryByCategoryId(id: number) {
        return $.ajax({
            url: '/customer/Subcategory/SubcategoryByCatId',
            type: 'GET',
            data: {
                id:id
            }
        });
    };
};