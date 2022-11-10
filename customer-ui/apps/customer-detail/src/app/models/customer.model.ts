export class Customer {
  id?: string;
  name: string;
  email: string;
  constructor(item: { id: string; name: string; email: string }) {
    this.id = item.id;
    this.name = item.name;
    this.email = item.email;
  }
}
