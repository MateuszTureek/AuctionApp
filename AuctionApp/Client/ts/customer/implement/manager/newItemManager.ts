import CategoryAjax from "../../../ajax/categoryAjax";

export default class NewItemManager {
    private $categorySelectList: JQuery<HTMLElement>;
    private $subcategorySelectList: JQuery<HTMLElement>;
    private $btnNewDescription: JQuery<HTMLElement>;
    private $btnDeleteDescription: JQuery<HTMLElement>;
    private $descriptionsContainer: JQuery<HTMLElement>;

    constructor(private categoryAjax: CategoryAjax) {
        this.$categorySelectList = $('#CatId');
        this.$subcategorySelectList = $('#SubcatId');
        this.$btnNewDescription = $('#BtnNewItemDescription');
        this.$btnDeleteDescription = $('#BtnDeleteItemDescription');
        this.$descriptionsContainer = $('#ItemDescriptions');

        this.events();
    };

    private events() {
        this.$categorySelectList.on('change', () => { this.categorySelectListOnChange(); });
        this.$btnNewDescription.on('click', () => { this.btnNewDescriptionOnClick(); });
        this.$btnDeleteDescription.on('click', () => { this.btnDeleteDescriptionOnClick(); });
    };


    private btnNewDescriptionOnClick() {
        this.generateDescriptionFields();
    };

    private btnDeleteDescriptionOnClick() {
        this.removeDescriptionFilds();
    };

    private removeDescriptionFilds() {
        const $descriptions = this.$descriptionsContainer.children('div.item-description-wrapper');
        const length = $descriptions.length;

        if (length > 0) {
            $descriptions.last().remove();
        }
    };

    private generateDescriptionFields() {
        const $descriptions = this.$descriptionsContainer.children('div.item-description-wrapper');
        
        const length = $descriptions.length;
        
        const containerStyles = 'item-description-wrapper col-lg-12 mb-1';
        
        let $container = $('<div>').addClass(containerStyles);

        let $titleRow = $('<div>').addClass('row mb-1');
        let $contentRow = $('<div>').addClass('row');

        let $lblTitle = $('<label>').addClass('col-lg-3').text('Tytuł:');
        let $lblContent = $('<label>').addClass('col-lg-3').text('Opis:');

        let $txtTitleWrpper = $('<div>').addClass('col-lg-9');
        let $txtAreaContentWrapper = $('<div>').addClass('col-lg-9');

        let $txtTitle = $('<input>').addClass('form-control').attr('title', 'text').attr('name', 'Descriptions[' + length + '].Key');
        let $txtAreaContent = $('<textarea>').addClass('form-control').attr('name', 'Descriptions[' + length + '].Value');

        $txtTitleWrpper.append($txtTitle);
        $titleRow.append($lblTitle);
        $titleRow.append($txtTitleWrpper);

        $txtAreaContentWrapper.append($txtAreaContent);
        $contentRow.append($lblContent);
        $contentRow.append($txtAreaContentWrapper);

        $container.append($titleRow);
        $container.append($contentRow);

        this.$descriptionsContainer.append($container);
    };

    private categorySelectListOnChange() {
        const value = this.$categorySelectList.val() as number;

        this.categoryAjax.getSubcategoryByCategoryId(value).then((selectListItemArray:any[]) => {
            this.$subcategorySelectList.empty();
            this.generateOptionToSelectList(this.$subcategorySelectList, selectListItemArray);
        }).catch((e) => { console.log('error'); });
    };

    private generateOptionToSelectList(selectList,items: any[]) {
        const length = items.length;
        let i = 0, $option: JQuery<HTMLElement>;

        for (i; i < length; i += 1) {
            $option = $('<option>');
            $option.text(items[i].text);
            $option.val(items[i].value);

            selectList.append($option);
        }
    };
};