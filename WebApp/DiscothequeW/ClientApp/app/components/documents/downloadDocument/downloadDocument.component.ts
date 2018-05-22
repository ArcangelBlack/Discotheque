import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { Http, Response, Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { DocumentModel } from '../../documents/Document.Model';
import { DocumentService } from "../../documents/Services/Document.service";

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';

@Component({
    selector: 'download-document',
    templateUrl: './downloadDocument.component.html',
    providers: [DocumentService]
})

export class downloadDocumentComponent {

    currentModel: DocumentModel = new DocumentModel();

    myBooks: string[] | undefined;

    constructor(private http: Http, private documentService: DocumentService, private route: Router, private _routeParams: ActivatedRoute) {

    }

    downloadFile() {

        this.documentService.getFile3().subscribe(data => {
            //this.currentModel = <DocumentModel>data;

            var blob = new Blob([data.Data], { type: 'application/octet-stream' });
            var url = window.URL.createObjectURL(blob);
            //window.open(url);
            //window.navigator.msSaveBlob(blob, "a.pdf");

            window.navigator.msSaveBlob(blob, 'SamplePdf.pdf');

        }, error => {
            if (error) {
                alert("Error al obtener el documento");
            }
        })
    }

    downloadFile00() {
        let options = new RequestOptions({ responseType: ResponseContentType.ArrayBuffer });
        return this.http.get('http://twppdf.azurewebsites.net/api/values/4', options).subscribe(data => {

            var filename = 'SamplePdf.pdf';

            var blob = new Blob([data.blob], { type: 'application/octet-stream' });

            if (window.navigator.msSaveOrOpenBlob) //IE & Edge
            {
                alert("IE & Edge");
                window.navigator.msSaveBlob(blob, filename);
            }
        }, error => {
            if (error) {
                alert("Error al obtener el documento");
            }
        });
    }

    downloadFile1() {

        let options = new RequestOptions({ responseType: ResponseContentType.ArrayBuffer });
        return this.http.get('http://twppdf.azurewebsites.net/api/values/4', options)
            .map((response: Response) => response).subscribe(data => {


                var rrr = data.json;
                var filename = 'SamplePdf.pdf';

                var blob = new Blob([data], { type: 'application/octet-stream' });

                if (window.navigator.msSaveOrOpenBlob) //IE & Edge
                {
                    alert("IE & Edge");
                    window.navigator.msSaveBlob(blob, filename);
                }
            }, error => {
                if (error) {
                    alert("Error al obtener el documento");
                }
            });
        //this.documentService.getDocument().subscribe(data => {
        //    this.currentModel = <DocumentModel>data;

        //    var url = window.URL.createObjectURL(data.Url);
        //    var a = document.createElement('a');
        //    var filename = 'a.pdf';
        //    document.body.appendChild(a);
        //    a.setAttribute('style', 'display: none');
        //    a.href = url;
        //    a.download = filename;
        //    a.click();
        //    window.URL.revokeObjectURL(url);
        //    a.remove(); // remove the element

        //}, error => {
        //    if (error) {
        //        alert("Error al obtener el documento");
        //    }
        //})
    }

    downloadFile2() {

        alert("Download 2");

        this.documentService.getFile3().subscribe(data => {
            try {

                var a = document.createElement("a");
                document.body.appendChild(a);
                var mediaType = 'application/pdf';
                var blob = new Blob([data.Data], { type: mediaType });
                var filename = 'a.pdf';
                a.href = window.URL.createObjectURL(blob);
                a.download = filename;
                a.innerHTML = filename;
                a.target = '_blank';
                a.click();
            }
            catch (err) {
                this.currentModel = err.toString();
            }
        }, error => {
            if (error) {
                alert("Error al obtener el documento");
            }
        })
    }

    downloadFile3() {

        //Original funcional
        this.documentService.getFile().subscribe(fileData => {

            //var filename = fileData.headers._headers['x-filename'];
            //var contentType = fileData.headers._headers['content-type'];

            var filename = 'SamplePdf.pdf';

            var linkElement = document.createElement('a');
            try {
                var blob = new Blob([fileData], { type: 'application/octet-stream' });

                if (window.navigator.msSaveOrOpenBlob) //IE & Edge
                {
                    alert("IE & Edge");
                    window.navigator.msSaveBlob(blob, filename);
                } else {
                    //var blob = new Blob([data], { type: contentType });
                    var url = window.URL.createObjectURL(blob);

                    linkElement.setAttribute('href', url);
                    linkElement.setAttribute("download", filename);

                    var clickEvent = new MouseEvent("click", {
                        "view": window,
                        "bubbles": true,
                        "cancelable": false
                    });
                    linkElement.dispatchEvent(clickEvent);
                }
            } catch (ex) {
                console.log(ex);
            }

            //var blob = new Blob([fileData], { type: contentType});
            //var filename = 'a.pdf';

            //if (window.navigator.msSaveOrOpenBlob) //IE & Edge
            //{
            //    alert("IE & Edge");
            //    window.navigator.msSaveBlob(blob, filename);
            //}
            //else {
            //    alert("Chrome, etc");

            //    var url = window.URL.createObjectURL(blob);
            //    var a = document.createElement('a');
            //    document.body.appendChild(a);
            //    a.setAttribute('style', 'display: none');
            //    a.href = url;
            //    a.download = filename;
            //    a.click();
            //    window.URL.revokeObjectURL(url);
            //    a.remove(); // remove the element
            //}
        });
    }

    downloadFile4(): void {

        //Original funcional
        this.documentService.getFile().subscribe(fileData => {

            //var filename = fileData.headers._headers['x-filename'];
            //var contentType = fileData.headers._headers['content-type'];

            var filename = 'SamplePdf.pdf';

            var linkElement = document.createElement('a');
            try {
                var blob = new Blob([fileData], { type: 'application/octet-stream' });

                if (window.navigator.msSaveOrOpenBlob) //IE & Edge
                {
                    alert("IE & Edge");
                    window.navigator.msSaveBlob(blob, filename);
                } else {
                    //var blob = new Blob([data], { type: contentType });
                    var url = window.URL.createObjectURL(blob);

                    linkElement.setAttribute('href', url);
                    linkElement.setAttribute("download", filename);

                    var clickEvent = new MouseEvent("click", {
                        "view": window,
                        "bubbles": true,
                        "cancelable": false
                    });
                    linkElement.dispatchEvent(clickEvent);
                }
            } catch (ex) {
                console.log(ex);
            }
        });

        //alert("Download 4");

        //this.documentService.getDocument().subscribe(data => {
        //    var b = new Blob([data.Data], { type: 'application/pdf' });
        //    var url = window.URL.createObjectURL(b);
        //    window.open(url);
        //}, error => {
        //    if (error) {
        //        alert("Error al obtener el documento");
        //    }
        //})
    }

    downloadFile5() {

        alert("Download 5");

        return this.documentService.getDocument().subscribe(res => {
            alert("Download 5");

            var filename = 'SamplePdf.pdf';
            var blob = new Blob([res.data], { type: 'application/octet-stream' });
            window.navigator.msSaveBlob(blob, filename);

            //console.log('start download:', res);
            //var url = window.URL.createObjectURL(res.data);
            //var a = document.createElement('a');
            //document.body.appendChild(a);
            //a.setAttribute('style', 'display: none');
            //a.href = url;
            //a.download = res.filename;
            //a.click();
            //window.URL.revokeObjectURL(url);
            //a.remove(); // remove the element
        }, error => {
            alert('download error:');
        }, () => {
            alert('Completed file download.')
        });
    }

    downloadFile6() {
        return this.http
            .get('http://twppdf.azurewebsites.net/api/values/4', {
                responseType: ResponseContentType.Blob,
                //search: // query string if have
            })
            .map(res => {
                return {
                    filename: 'filename.pdf',
                    data: res.blob()
                };
            })
            .subscribe(res => {
                //console.log('start download:', res);
                //var url = window.URL.createObjectURL(res.data);
                //var a = document.createElement('a');
                //document.body.appendChild(a);
                //a.setAttribute('style', 'display: none');
                //a.href = url;
                //a.download = res.filename;
                //a.click();
                //window.URL.revokeObjectURL(url);
                //a.remove(); // remove the element
            }, error => {
                console.log('download error:', JSON.stringify(error));
            }, () => {
                console.log('Completed file download.')
            });
    }

    downloadFile7(): void {
        this.getFile("http://twppdf.azurewebsites.net/api/values/4")
            .subscribe(fileData => {

                var filename = 'a.pdf';

                if (window.navigator.msSaveOrOpenBlob) //IE & Edge
                {
                    alert("IE & Edge");

                    let b: any = new Blob([fileData], { type: 'application/octet-stream' });
                    //var url = window.URL.createObjectURL(b);
                    //window.open(url);

                    window.navigator.msSaveBlob(b, filename);
                } else {

                    alert("Chrome, Other");

                    var linkElement = document.createElement('a');
                    var blob = new Blob([fileData], { type: 'application/pdf' });

                    var url = window.URL.createObjectURL(blob);

                    linkElement.setAttribute('href', url);
                    linkElement.setAttribute("download", filename);

                    var clickEvent = new MouseEvent("click", {
                        "view": window,
                        "bubbles": true,
                        "cancelable": false
                    });
                    linkElement.dispatchEvent(clickEvent);
                }
            }
            );
    }


    public getFile(path: string): Observable<any> {
        let options = new RequestOptions({ responseType: ResponseContentType.Blob });
        return this.http.get(path, options)
            .map((response: Response) => <Blob>response.blob());
    }
}