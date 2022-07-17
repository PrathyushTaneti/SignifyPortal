export class Teacher{
    name: string;
    emailAddress: string;
    subject: string;
    department: string;
    constructor(args: Teacher) {
        this.name = args.name;
        this.emailAddress = args.emailAddress;
        this.subject = args.subject;
        this.department = args.department;
    }
}