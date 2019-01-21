import { Component, OnInit } from '@angular/core';
import { HubConnection, LogLevel, HubConnectionBuilder } from '@aspnet/signalr';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private hubConnection: HubConnection;
  public Messages: Array<string>;

  ngOnInit() {
    const builder = new HubConnectionBuilder();
    this.hubConnection = builder.withUrl('https://localhost:44356/NotificationsHub')
      .configureLogging(LogLevel.Information)
      .build();
    this.hubConnection.start().then(_ => { }).catch(err => { console.error(err); });
    this.hubConnection.on('Notifications', (message) => { console.log(message); });
  }
}
