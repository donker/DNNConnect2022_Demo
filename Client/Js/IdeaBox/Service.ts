import { IIdea } from "./Models/IIdea";

export interface DnnServiceFramework extends JQueryStatic {
    dnnSF(moduleId: number): DnnServiceFramework;
    getServiceRoot(path: string): string;
    setModuleHeaders(): void;
    getTabId(): string;
}

export default class DataService {
    private moduleId: number = -1;
    private dnn: DnnServiceFramework = <DnnServiceFramework>$;
    public baseServicepath: string = this.dnn.dnnSF(this.moduleId).getServiceRoot('Connect/IdeaBox');
    public tabId: string = this.dnn.dnnSF(this.moduleId).getTabId();
    constructor(mid: number) {
        this.moduleId = mid;
    };
    private ajaxCall(type: string, servicePath: string, controller: string, action: string, id: any, headers: any, data: any, success: Function, fail?: Function, isUploadForm?: boolean)
        : void {
        var opts: JQuery.AjaxSettings = {
            headers: headers,
            type: type === "POSTFORM" ? "POST": type,
            url: servicePath + controller + '/' + action + (id != undefined
                ? '/' + id
                : ''),
            beforeSend: this
                .dnn
                .dnnSF(this.moduleId)
                .setModuleHeaders,
            contentType: type === "POSTFORM" ? undefined : "application/json; charset=utf-8",
            data: type == "POST" ? JSON.stringify(data) : data,
            dataType: "json"
        };
        if (isUploadForm) {
            opts.contentType = false;
            opts.processData = false;
        }
        $.ajax(opts)
            .done(function (retdata: any) {
                if (success != undefined) {
                    success(retdata);
                }
            })
            .fail(function (xhr: any, status: any) {
                if (fail != undefined) {
                    fail(xhr.responseText);
                }
            });
    };
    public getIdeas(success: Function): void {
        this.ajaxCall('GET', this.baseServicepath, 'Ideas', 'List', undefined, {}, null, success)
    }
    public updateIdea(idea: IIdea, success: Function): void {
        this.ajaxCall('POST', this.baseServicepath, 'Ideas', 'Update', undefined, {}, idea, success)
    }
    public deleteIdea(ideaId: number, success: Function): void {
        this.ajaxCall('POST', this.baseServicepath, 'Ideas', 'Delete', ideaId, {}, null, success)
    }
    public vote(ideaId: number, vote: number, success: Function): void {
        this.ajaxCall('POST', this.baseServicepath, 'Votes', 'Vote', undefined, {}, { IdeaId: ideaId, UserId: -1, Karma: vote }, success)
    }
}
