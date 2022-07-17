export class Student{
    id: number;
    firstName: string;
    lastName: string;
    mobileNumber: string;
    gender: string;
    course: string;
    rollNumber: string;
    guardianName: string;
    address: string;
    department: string;
    profilePicture: string;
    constructor(args: any) {
        this.id = args.id;
        this.firstName = args.firstName;
        this.lastName = args.lastName;
        this.mobileNumber = args.mobileNumber;
        this.gender = args.gender;
        this.rollNumber = args.rollNumber;
        this.course = args.course;
        this.guardianName = args.guardianName;
        this.address = args.address;
        this.department = args.department;
        this.profilePicture = args.profilePicture;
    }
}