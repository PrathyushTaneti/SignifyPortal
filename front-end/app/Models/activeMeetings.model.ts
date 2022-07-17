export class ActiveMeetings{
    id: number;
    joinLink: string;
    subject: string
    constructor(joinLink: string, subject: string) {
        this.id = 0;
        this.joinLink = joinLink;
        this.subject = subject;
    }
}