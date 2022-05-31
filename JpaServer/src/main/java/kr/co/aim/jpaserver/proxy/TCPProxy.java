package kr.co.aim.jpaserver.proxy;

import java.io.IOException;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.jpaserver.data.ChattingData;
import kr.co.aim.jpaserver.manager.MemberManager;
import kr.co.aim.jpaserver.manager.RoomManager;
import kr.co.aim.jpaserver.service.ChattingService;

@Component
public class TCPProxy implements MessageCallBack {

	private TCPInterface tcpInterface;
	private final int PORT = 9000;

	@Autowired
	private MemberManager memberManager;
	
	@Autowired
	private RoomManager roomManager;
	
	@Autowired
	private ChattingService chattingService;

	//@PostConstruct
	private void Open() {
		this.tcpInterface = new TCPInterface(PORT, memberManager, roomManager, this);
		this.tcpInterface.Open();

		System.out.println(String.format("Start Server Port=%s", PORT));
	}

	public void close() {
		this.tcpInterface.close();
	}

	@Override
	public void onMessage(Object msg) {
		if(!(msg instanceof ChattingData)) {
			return;
		}
		
		try {
			ChattingData chattingData = (ChattingData)msg;
			chattingService.echo(chattingData);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
