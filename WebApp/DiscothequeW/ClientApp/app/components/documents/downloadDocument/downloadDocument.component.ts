import { Component, Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { DocumentService } from "../Services/Document.service";
import { DocumentModel } from '../Document.Model';

@Component({
    selector: 'download-document',
    templateUrl: './downloadDocument.component.html',
    providers: [DocumentService]
})

export class downloadDocumentComponent {

    currentModel: DocumentModel = new DocumentModel();

    constructor(private documentService: DocumentService) { }


    downloadFile() {
        this.documentService.getDocument().subscribe(data => {
            this.currentModel = <DocumentModel>data;
        }, error => {
            if (error) {
                alert("Error al obtener el documento");
            }
        })
    }

    //downloadFile1() {
    //    //var blob = new Blob([data], { type: 'text/csv' });
    //    //var url = window.URL.createObjectURL(blob);
    //    //window.open(url);

    //    alert("1");

    //    this.currentModel = "http://twppdf.azurewebsites.net/api/values/4";

    //    return this.http
    //        .get('http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf', {
    //            responseType: ResponseContentType.Blob,
    //            //search: // query string if have
    //        })
    //        .map(res => {
    //            return {
    //                filename: 'filename.pdf',
    //                data: res.blob()
    //            };
    //        })
    //        .subscribe(res => {
    //            console.log('start download:', res);
    //            var url = window.URL.createObjectURL(res.data);
    //            var a = document.createElement('a');
    //            document.body.appendChild(a);
    //            a.setAttribute('style', 'display: none');
    //            a.href = url;
    //            a.download = res.filename;
    //            a.click();
    //            window.URL.revokeObjectURL(url);
    //            a.remove(); // remove the element
    //        }, error => {
    //            console.log('download error:', JSON.stringify(error));
    //        }, () => {
    //            console.log('Completed file download.')
    //        });
    //}

    //downloadFile2() {

    //    alert("Download 2 ");

    //    return this.http
    //        .get('http://twppdf.azurewebsites.net/api/values/4', {
    //            responseType: ResponseContentType.ArrayBuffer,
    //        })
    //        .map(res => {
    //            return {
    //                filename: 'a.pdf',
    //                data: res.arrayBuffer
    //            };
    //        })
    //        .subscribe(res => {
    //           var url = window.URL.createObjectURL(res.data);
    //            var a = document.createElement('a');
    //            document.body.appendChild(a);
    //            a.setAttribute('style', 'display: none');
    //            a.href = url;
    //            a.download = res.filename;
    //            //a.type = "application/pdf"
    //            a.click();
    //            window.URL.revokeObjectURL(url);
    //            a.remove(); // remove the element
    //        }, error => {

    //            alert("Error XD");

    //            alert(JSON.stringify(error));
    //        }, () => {
    //            alert('Completed file download.')
    //        });
    //}


    //downloadFile3() {
    //    //var blob = new Blob([data], { type: 'text/csv' });
    //    //var url = window.URL.createObjectURL(blob);
    //    //window.open(url);

    //    alert("Download 3");

    //    this.currentModel = "http://twppdf.azurewebsites.net/api/values/4";

    //    this.http.get(
    //        'http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf').subscribe(
    //            (response) => {
    //                try {
    //                    //var mediaType = 'application/pdf';
    //                    //var blob = new Blob([response], { type: mediaType });
    //                    //var filename = 'butlleta_2015000510.pdf';
    //                    ////saveAs(blob, filename);
    //                    //var url = window.URL.createObjectURL(blob);
    //                    //window.open(url);

    //                    let a = document.createElement("a");
    //                    document.body.appendChild(a);
    //                    var mediaType = 'application/pdf';
    //                    var blob = new Blob([response.blob], { type: mediaType });
    //                    var filename = 'a.pdf';
    //                    a.href = window.URL.createObjectURL(blob);
    //                    a.download = filename;
    //                    a.innerHTML = filename;
    //                    a.target = '_blank';
    //                    a.click();

    //                    alert("2");
    //                }
    //                catch (err) {
    //                    this.currentModel = err.toString();
    //                    alert("3");
    //                }
    //            });

    //}

    //downloadFile4(): void {

    //    alert("Download 4");

    //    this.getFile("http://twppdf.azurewebsites.net/api/values/4")
    //        .subscribe(fileData => {
    //            let b: any = new Blob([fileData], { type: 'application/pdf' });
    //            var url = window.URL.createObjectURL(b);
    //            window.open(url);
    //        }
    //        );
    //}

    //public getFile(path: string): Observable<any> {
    //    let options = new RequestOptions({ responseType: ResponseContentType.Blob });
    //    return this.http.get(path, options)
    //        .map((response: Response) => <Blob>response.blob());
    //}


    //public downloadFile5() {

    //    alert("Download 5");

    //    this.downloadPdf().subscribe(
    //        (fileData : any) => {
    //            saveAs(fileData, 'a.pdf')
    //        }
    //    );
    //}

    //public downloadPdf(): any {
    //    let url = 'http://twppdf.azurewebsites.net/api/values/4'
    //    let headers = new Headers();
    //    return this.http.get(url, { headers: headers, responseType: ResponseContentType.ArrayBuffer }).map(
    //        (res) => {
    //            return new Blob([res.blob()], { type: 'application/pdf' })
    //        })
    //}

    //private options = new RequestOptions(
    //    { headers: new Headers({ 'responseType': 'ResponseContentType.Blob', 'Content-Type': 'application/json' }) });

    //downloadSampleCSVFiles() {
    //    var nameOfFileToDownload = "a.pdf";
    //    var result = this.downloadSampleCSV(nameOfFileToDownload);
    //    result.subscribe(
    //        success => {
    //            var blob = new Blob([success.blob], { type: 'application/pdf' });

    //            if (window.navigator && window.navigator.msSaveOrOpenBlob) {
    //                window.navigator.msSaveOrOpenBlob(blob, nameOfFileToDownload);
    //            } else {
    //                var a = document.createElement('a');
    //                a.href = URL.createObjectURL(blob);
    //                a.download = nameOfFileToDownload;
    //                document.body.appendChild(a);
    //                a.click();
    //                document.body.removeChild(a);
    //            }
    //        },
    //        err => {
    //            alert("Server error while downloading file.");
    //        }
    //    );
    //}

    //downloadSampleCSV(fileNameToDownload: string) {
    //    return this.http.post("http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf", fileNameToDownload, this.options);
    //}

    //downloadFile5() {
    //    return this.http
    //        .get('http://unec.edu.az/application/uploads/2014/12/pdf-sample.pdf',
    //            { headers: new Headers({ 'Content-Type': 'application/json' }), responseType: ResponseContentType.Blob })
    //}

    //DownloadExcelFile99(): Observable<any> {
    //    return this.http.get('http://twppdf.azurewebsites.net/api/values/4', this.options);
    //} 
}