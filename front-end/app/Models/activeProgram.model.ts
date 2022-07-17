export class ActivePrograms{
    id: number;
    programLink: string;
    programName: string;
    constructor(programLink: string, programName: string) {
        this.id = 0;
        this.programLink = programLink;
        this.programName = programName;
    }
}