
export class QueryObject {
  sortBy?: string = 'name';
  isSortAscending?: boolean = true;
  page: number = 1;
  pageSize: number = 5;
  public constructor(init?: Partial<QueryObject>) {
    Object.assign(this, init);
  }
}
export class QueryResult {
  totalItems: number = 0;
  items: any[] = [];
}

export class IncidentQueryObject extends QueryObject {
  public constructor(init?: Partial<IncidentQueryObject>) {
    super(init);
    Object.assign(this, init);
  }
  name?: string;
  description?:number;
}


