const Discord = require('discord.js');
const client = new Discord.Client();
const fs = require('fs');

const channels = [];

const dir = require('path').resolve(__dirname, '..');
fs.readdir(dir, (err, files) => {
	files.forEach(file => {
	  if (file.includes('.bat'))
		//console.log(file.replace(".bat",""));
		channels.push(file.replace(".bat",""));
	});
  });

channels.forEach(x => {exampleEmbed.addField(x, "a");});
client.on('ready', () => {
	console.log("Started");
	if (client.user.username != "EzStreaming"){
	client.user.setAvatar("avatar.ico");
	client.user.setUsername("EzStreaming");}
});

client.on('message', msg => {
		const args = msg.content.split(' ');
		if (args[0] === '!start' && args[1] != undefined && channels.includes(args[1])) {
			msg.channel.send("Start: " + args[1]);
			console.log("Start: " + args[1]);
		}
		if (args[0] === '!stop' && args[1] != undefined && channels.includes(args[1])) {
			msg.channel.send("Stop: " + args[1]);
			console.log("Stop: " + args[1]);
		}
		if (args[0] === '!channels') {
			msg.channel.send("Channels: " + channels);
		}
		if (args[1] == undefined &! args[0] === '!channels') msg.reply("Error: You Don't Set Channel");
		if (args[0] === '!stop' && args[1] != undefined && !channels.includes(args[1])) msg.channel.send("Error: Imposible Stop this Channel no exist");
		if (args[0] === '!start' && args[1] != undefined && !channels.includes(args[1])) msg.channel.send("Error: Imposible Start this Channel no exist");
  });
client.login(process.argv[2]);