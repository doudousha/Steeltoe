package cloud.wq.client;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

@RestController
public class MemberController {


    @Autowired
    @Qualifier(value="restTemplate")
    RestTemplate restTemplate ;

    @RequestMapping("/getMember")
    public String getMember(){
        return "this is a  member service:会员服务";
    }


    @RequestMapping("/test")
    public String test(){

     //  String result =   this.restTemplate.getForEntity("http://NETCORE-SERVICE/api/myService/test",String.class).getBody();
        String result =   this.restTemplate.getForEntity("http://EUREKAKCONSUMER02/order/test",String.class).getBody();



        return result;
    }



    @RequestMapping("/NetService")
    public String NetService(){

        //  String result =   this.restTemplate.getForEntity("http://NETCORE-SERVICE/api/myService/test",String.class).getBody();
        String result =   this.restTemplate.getForEntity("http://NETCORE-SERVICE/api/MyService/test",String.class).getBody();



        return result;
    }

}
