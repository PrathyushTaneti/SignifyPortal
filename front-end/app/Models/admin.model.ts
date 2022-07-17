export class Admin{
    emailAddress: string;
    password: string;
    constructor(args: Admin) {
        this.emailAddress = args.emailAddress;
        this.password = args.password;
    }
}