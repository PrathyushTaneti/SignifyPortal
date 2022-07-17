export class Performance{
    id: number;
    rollNumber: string;
    performanceOfStudent: string;
    quizName: string;
    constructor(rollNumber:string,performance:string,quizName:string) {
        this.id = 0;
        this.rollNumber = rollNumber;
        this.performanceOfStudent = performance;
        this.quizName = quizName;
    }
}