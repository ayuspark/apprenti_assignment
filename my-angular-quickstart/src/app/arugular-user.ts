export class ArugularUser {
    public username: string;
    public email: string;
    public address?: string;

    private _password: string; 
    get getPassword(): string{
        return this._password
    }

    constructor(username:string, email:string, password:string, address?:string){
        this.username = username;
        this._password = password;
        this.email = email;
        this.address = address;
    }
}
