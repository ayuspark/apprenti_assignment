export class Switches 
{
    switchBool:boolean;
    switchStatus: string;
    constructor(switchBool:boolean, switchStatus:string){
        this.switchBool = switchBool;
        this.switchStatus = switchStatus;
    }
    turnSwitch(): void {
        this.switchBool = !this.switchBool;
        this.switchStatus = (this.switchBool) ? "ON" : "OFF";
    }
}