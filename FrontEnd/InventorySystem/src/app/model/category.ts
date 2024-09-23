export interface ICategory {
    id : number,
    categoryId : string,
    categoryName: string,
    description: string,
    isActivated: boolean
}

export interface IAddNewCategory
{
    categoryId  : string,
    categoryName: string,
    description: string,
    isActivated: boolean
}

export interface IUpdateCategory
{
    categoryId : string,
    categoryName : string,
    description : string,
    isActivated : boolean
}
