export class NewMeeting{
    meetingUrl: string;
    subject: string;
    constructor(meetingUrl:string, subject:string) {
        this.meetingUrl = meetingUrl;
        this.subject = subject;
    }
}