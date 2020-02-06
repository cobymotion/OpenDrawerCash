import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.PrintStream;

public class Main {
    public static void main(String ...a){
        Main m = new Main(); 
        m.cashdrawerOpen(); 
    }

    public void cashdrawerOpen(){ 
    String code2 = "1B700096FA"; // my code in hex
    FileOutputStream os = null;
    try {
        os = new FileOutputStream("LPT1:XP-58");
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    }
      PrintStream ps = new PrintStream(os);
    ps.print(toAscii(code2));
      ps.close();
}

public StringBuilder toAscii( String hex ){
StringBuilder output = new StringBuilder();
for (int i = 0; i < hex.length(); i+=2) {
String str = hex.substring(i, i+2);
output.append((char)Integer.parseInt(str, 16));
}
 return output;

}
}